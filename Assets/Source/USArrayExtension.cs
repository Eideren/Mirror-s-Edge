namespace MEdge.Engine{
    using System; using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

    public static class USArrayExtension
    {
        public static int Find<T, T2>(this array<T> a, name tMemberName, IStaticArray<T2> c) where T2 : unmanaged
        {
            // Hardcoded for now, rare function in source
            switch (tMemberName.Value)
            {
                case "Uid":
                {
                    if( a is array<OnlineSubsystem.UniqueNetId> uidArray && c is IStaticArray<byte> byteSpan )
                    {
                        for( int i = 0; i < uidArray.Length; i++ )
                        {
                            var netId = uidArray[ i ];
                            if( netId.Uid.Length != byteSpan.Length )
                                continue;

                            bool mismatch = false;
                            for( int j = 0; j < byteSpan.Length; j++ )
                            {
                                if( netId.Uid[ j ] != byteSpan[ j ] )
                                    mismatch = true;
                            }
                            if(mismatch)
                                continue;
                            

                            return i;
                        }
                    }

                    break;
                }
                default:
                    throw new NotImplementedException(tMemberName.Value);
            }

            return -1;
        }
    }
}