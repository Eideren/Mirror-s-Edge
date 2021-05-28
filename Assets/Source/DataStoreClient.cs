namespace MEdge.Engine
{
    public partial class DataStoreClient
    {
        
	
        // Export UDataStoreClient::execCreateDataStore(FFrame&, void* const)
        public virtual /*native final function */ T CreateDataStore<T>(Core.ClassT<T> DataStoreClass) where T : UIDataStore
        {
            return CreateDataStore(DataStoreClass as Core.ClassT<UIDataStore>) as T;
        }
    }
}