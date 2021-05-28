using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
#if CSHARP_7_3_OR_NEWER
using UnityEngine;
#endif
namespace MEdge
{
public static class T3D
{
    public static bool ExtractPropFromString( string str, out string name, out string value, out string namedIndex )
    {
        var equalSignPos = str.IndexOf('=');
        if (equalSignPos == -1)
        {
            name = value = "";
            namedIndex = null;
            return false;
        }
        var nameLength = equalSignPos;
        namedIndex = null;
        var indexPos = str.IndexOf('(', 0, equalSignPos);
        if (indexPos != -1)
        {
            var indexEndPos = str.IndexOf(')', 0, equalSignPos);
            if (indexEndPos != -1)
            {
                namedIndex = str.Substring(indexPos, indexEndPos - indexPos+1);
                nameLength = indexPos;
            }
        }

        name = str.Substring(0, nameLength);
        value = str.Remove(0, equalSignPos+1);
        return true;
    }

    

    public static string KeywordAfter(string inputString, string delimiter)
    {
        TryExtractKeywordAfter(inputString, delimiter, out var output);
        return output;
    }

    

    public static bool TryExtractKeywordAfter(string inputString, string delimiter, out string keyword)
    {
        var start = inputString.IndexOf(delimiter, StringComparison.Ordinal);
        if (start == -1)
        {
            keyword = null;
            return false;
        }

        start += delimiter.Length;

        int parenBalance = 0;
        int end = start;
        for (; end < inputString.Length; end++)
        {
            var c = inputString[end];
            if (char.IsWhiteSpace(c) || c == '=' || c == ',')
                break;
            if (c == '(')
                parenBalance++;
            if (c == ')')
                parenBalance--;
            
            if (parenBalance < 0)
                break;
        }

        keyword = inputString.Substring(start, end - start);
        return true;
    }

    

    public static void DeserializeOnObject(ref object thisObj, string name, string value, string indexStr, MappingFixer mappingFixer)
    {
        try
        {
            MemberInfo member = thisObj.GetType().GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) 
                                ?? thisObj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) as MemberInfo;
            if (member == null)
            {
                mappingFixer( ref thisObj, name, value );
                return;
            }

            Type fType = (member as FieldInfo)?.FieldType ?? (member as PropertyInfo)!.PropertyType;
            foreach (var iType in fType.GetInterfaces())
            {
                if (iType.IsGenericType == false || iType.GetGenericTypeDefinition() != typeof(IList<>))
                    continue;
                    
                Type itemType = fType.GetGenericArguments()[0];
                var index = int.Parse(indexStr.Replace("(", "").Replace(")", ""));
                IList list;
                list = (member as FieldInfo)?.GetValue(thisObj) as IList;
                list ??= (member as PropertyInfo)?.GetValue(thisObj) as IList;
                while (list.Count <= index)
                    list.Add(itemType.IsValueType ? Activator.CreateInstance( itemType ) : null);
                object refL = list;
                Deserialize(ref refL, name + indexStr, value, out var val, itemType, mappingFixer, out var handled);
                if( handled == false )
                    list[index] = val;
                return;
            }

            {
                Deserialize(ref thisObj, name + indexStr, value, out var val, fType, mappingFixer, out var handled);
                if (handled == false)
                {
                    (member as FieldInfo)?.SetValue(thisObj, val);
                    (member as PropertyInfo)?.SetValue(thisObj, val);
                }
            }
            
            return;
        }
        catch (Exception e)
        {
            #if CSHARP_7_3_OR_NEWER
            Debug.LogException(e);
            #endif
            mappingFixer( ref thisObj, name, value );
            return;
        }
    }



    static void Deserialize(ref object obj, string objPropName, string valString, out object val, Type expectedType, MappingFixer mappingFixer, out bool handled)
    {
        valString = valString.Trim();
        handled = false;
        val = Type.GetTypeCode(expectedType) switch
        {
            TypeCode.Boolean => Boolean.Parse(valString),
            TypeCode.Char => Char.Parse(valString),
            TypeCode.SByte => SByte.Parse(valString),
            TypeCode.Byte => Byte.Parse(valString),
            TypeCode.Int16 => Int16.Parse(valString),
            TypeCode.UInt16 => UInt16.Parse(valString),
            TypeCode.Int32 => Int32.Parse(valString),
            TypeCode.UInt32 => UInt32.Parse(valString),
            TypeCode.Int64 => Int64.Parse(valString),
            TypeCode.UInt64 => UInt64.Parse(valString),
            TypeCode.Single => Single.Parse(valString),
            TypeCode.Double => Double.Parse(valString),
            TypeCode.Decimal => Decimal.Parse(valString),
            TypeCode.DateTime => DateTime.Parse(valString),
            TypeCode.String => valString[0] == '"' && valString[valString.Length - 1] == '"' ? valString.Trim('"') : valString,
            _ when expectedType.IsValueType 
                   && valString[0] == '(' && valString[valString.Length - 1] == ')'
                => DeserializeComplexObject( valString, expectedType, mappingFixer ),
            _ => RunFixer(ref obj, objPropName, valString, mappingFixer, out handled)
        };

        static object RunFixer(ref object obj, string objPropName, string valString, MappingFixer mappingFixer, out bool handled)
        {
            handled = true;
            mappingFixer(ref obj, objPropName, valString);
            return null;
        }
    }

    const string BracketBalancePattern = @"(?<Balance>\{(?>\{(?<c>)|[^{}]+|\}(?<-c>))*(?(c)(?!))\})";
    const string ParenBalancePattern =   @"(?<Balance>\((?>\((?<c>)|[^()]+|\)(?<-c>))*(?(c)(?!))\))";
    
    static object DeserializeComplexObject(string valString, Type expectedType, MappingFixer mappingFixer)
    {
        valString = valString.Remove(valString.Length - 1, 1).Remove(0, 1);

        List<string> props = new List<string>();
        // extract params while being careful with parenthesis content 
        foreach (Match match in Regex.Matches(valString, $@"[^,]*?{ParenBalancePattern}*,"))
        {
            var str = match.Value.Trim().TrimEnd(',');
            if (str.Length > 2 && str[0] == '(' && str[str.Length - 1] == ')')
                str = str.Substring(0, str.Length - 1).Remove(0, 1);
            props.Add( str );
        }
        // Last or only param
        foreach (Match match in Regex.Matches(valString, @"[^,]+$"))
            props.Add( match.Value.Trim() );
        var thisObj = Activator.CreateInstance(expectedType);
        foreach (string prop in props)
        {
            ExtractPropFromString(prop, out var name, out var value, out var index);
            DeserializeOnObject(ref thisObj, name, value, index, mappingFixer);
        }

        return thisObj;
    }
}
}