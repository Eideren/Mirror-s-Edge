namespace MEdge.Engine
{
	public partial class SkelControlBase
	{
		public virtual /*native final function */void SetSkelControlStrength(float NewStrength, float InBlendTime)
		{
			// Make sure parameters are valid
			NewStrength = Clamp<float>(NewStrength, 0f, 1f);
			InBlendTime	= Max(InBlendTime, 0f);

			if( StrengthTarget != NewStrength || InBlendTime < BlendTimeToGo )
			{
				StrengthTarget	= NewStrength;
				BlendTimeToGo	= InBlendTime;

				// If blend time is zero, apply now and don't wait a frame.
				if( BlendTimeToGo <= 0f )
				{
					ControlStrength = StrengthTarget;
					BlendTimeToGo	= 0f;
				}
			}
		}
	}
}