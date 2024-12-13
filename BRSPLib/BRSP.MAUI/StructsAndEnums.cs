using System;

namespace BlueRadios
{
    public enum BrspMode {
        Idle = 0,
        Data = 1,
        RemoteCommand = 2,
        FirmwareUpdate = 4, //Not implemented yet
    };
}

