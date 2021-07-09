using MEdge.Engine;

namespace MEdge.Core
{
    public static class NullRef
    {
        public static ref array<int> array_int_
        {
            get
            {
                _back_array_int_ = default;
                return ref _back_array_int_;
            }
        }
        static array<int> _back_array_int_;
        public static ref array<SequenceEvent> array_SequenceEvent_
        {
            get
            {
                _back_array_SequenceEvent_ = default;
                return ref _back_array_SequenceEvent_;
            }
        }
        static array<SequenceEvent> _back_array_SequenceEvent_;
        public static ref Actor.TraceHitInfo Actor_TraceHitInfo
        {
            get
            {
                _back_Actor_TraceHitInfo = default;
                return ref _back_Actor_TraceHitInfo;
            }
        }
        static Actor.TraceHitInfo _back_Actor_TraceHitInfo;
        public static ref Object.Vector Object_Vector
        {
            get
            {
                _back_Object_Vector = default;
                return ref _back_Object_Vector;
            }
        }
        static Object.Vector _back_Object_Vector;
    }
}