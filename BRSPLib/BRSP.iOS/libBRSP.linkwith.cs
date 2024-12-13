using System;
using ObjCRuntime;

[assembly: LinkWith("libBRSP.a", LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, ForceLoad = true)]
