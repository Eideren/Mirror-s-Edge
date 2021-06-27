namespace MEdge.Engine
{
    public partial class OnlineSubsystem
    {
        public unsafe partial struct /*native */UniqueNetId
        {
            public static bool operator ==(UniqueNetId a, UniqueNetId b)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (a.Uid[i] != b.Uid[i])
                        return false;
                }

                return true;
            }

            public static bool operator !=(UniqueNetId a, UniqueNetId b) => (a == b) == false;
        }
    }
}