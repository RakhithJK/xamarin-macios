using System;
using System.Runtime.InteropServices;

using Foundation;
using ObjCRuntime;

using MatrixFloat2x2 = global::OpenTK.NMatrix2;
using MatrixFloat3x3 = global::OpenTK.NMatrix3;
using MatrixFloat4x3 = global::OpenTK.NMatrix4x3;
using MatrixFloat4x4 = global::OpenTK.NMatrix4;

namespace Bindings.Test
{
	public unsafe partial class EvilDeallocator : NSObject
	{
		public void MarkMeDirty ()
		{
			MarkDirty ();
		}
	}
}
