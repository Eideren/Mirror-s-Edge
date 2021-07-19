namespace MEdge.Ts{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TsTester : Object/*
		transient
		native*/{
	public/*private*/ TsSystem.TsSaveData WriteData;
	public/*private*/ StaticArray<TsSystem.TsSaveData, TsSystem.TsSaveData, TsSystem.TsSaveData>/*[3]*/ MultiWriteData;
	
	public virtual /*event */void TestWrite(int Id, int Size)
	{
		// stub
	}
	
	public virtual /*function */void TestWriteDone(TsSystem.ETsResult Result)
	{
		// stub
	}
	
	public virtual /*event */void TestRead(int Id)
	{
		// stub
	}
	
	public virtual /*function */void TestReadDone(TsSystem.ETsResult Result, array<byte> ReadBuffer)
	{
		// stub
	}
	
	public virtual /*event */void TestMultiWrite(int Size)
	{
		// stub
	}
	
	public virtual /*function */void MultiWrite1Done(TsSystem.ETsResult Result)
	{
		// stub
	}
	
	public virtual /*function */void MultiWrite2Done(TsSystem.ETsResult Result)
	{
		// stub
	}
	
	public virtual /*function */void MultiWrite3Done(TsSystem.ETsResult Result)
	{
		// stub
	}
	
}
}