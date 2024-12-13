using System;
using System.Drawing;
using ObjCRuntime;
using Foundation;
using UIKit;
using CoreBluetooth;

namespace BlueRadios
{
    [BaseType(typeof(NSObject))]
    [Model]
    [Protocol]
    interface BrspDelegate
    {
        //- (void)brsp:(Brsp*)brsp OpenStatusChanged:(BOOL)isOpen;
        [Abstract]
        [Export("brsp:OpenStatusChanged:"), EventArgs("OpenStatus")]
        /// <summary>
        /// Called when the open status has changed after a call to either open or close.
        /// No writes etc will work until this method is called with an isOpen status of YES.
        /// </summary>
        /// <param name='brsp'>
        /// The Brsp object generating this event.
        /// </param>
        /// <param name='isOpen'>
        /// If set to <c>true</c> is open.
        /// </param>
        void OpenStatusChanged(Brsp brsp, bool isOpen);
        //- (void)brsp:(Brsp*)brsp SendingStatusChanged:(BOOL)isSending;
        [Abstract]
        [Export("brsp:SendingStatusChanged:"), EventArgs("SendingStatus")]
        void SendingStatusChanged(Brsp brsp, bool isSending);
        //- (void)brspDataReceived:(Brsp*)brsp;
        [Export("brspDataReceived:")]
        void DataReceived(Brsp brsp);
        //- (void)brsp:(Brsp*)brsp ErrorReceived:(NSError*)error;
        [Export("brsp:ErrorReceived:"), EventArgs("Error")]
        void ErrorReceived(Brsp brsp, NSError error);
        //- (void)brspModeChanged:(Brsp*)brsp BRSPMode:(BrspMode)mode;
        [Export("brspModeChanged:BRSPMode:"), EventArgs("Mode")]
        void ModeChanged(Brsp brsp, BrspMode mode);
    }
    //    [BaseType (typeof (UIViewController), Name="ATMHud", Delegates=new string [] { "WeakDelegate" }, Events=new Type [] { typeof (AtmHudDelegate)})]
    //    interface AtmHud {
    //        [Export ("delegate"), NullAllowed]
    //        NSObject WeakDelegate { get; set; }
    //
    //        [Wrap ("WeakDelegate")]
    //        AtmHudDelegate Delegate { get; set; }
    // ...
    [BaseType(typeof(CBPeripheralDelegate), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof(BrspDelegate) })]
    interface Brsp
    {
        //@property (nonatomic, weak) id <BrspDelegate> delegate;
        [Wrap("WeakDelegate")]
        BrspDelegate Delegate { get; set; }

        [Export("delegate")][NullAllowed]
        NSObject WeakDelegate { get; set; }
        //@property (nonatomic, readonly) BrspMode brspMode;
        [Export("brspMode")]
        BrspMode Mode { get; }
        //@property (nonatomic, readonly) CBPeripheral *peripheral;
        [Export("peripheral")]
        CBPeripheral Peripheral { get; }
        //@property (nonatomic, readonly) NSUInteger securityLevel;
        [Export("securityLevel")]
        uint SecurityLevel { get; }
        //@property (nonatomic, readonly) BOOL isOpen;
        [Export("isOpen")]
        bool IsOpen { get; }
        //@property (nonatomic, readonly) BOOL isSending;
        [Export("isSending")]
        bool IsSending { get; }
        //@property (nonatomic, readonly) NSUInteger inputBufferSize;
        [Export("inputBufferSize")]
        uint InputBufferSize { get; }
        //@property (nonatomic, readonly) NSUInteger outputBufferSize;
        [Export("outputBufferSize")]
        uint OutputBufferSize { get; }
        //@property (nonatomic, readonly) NSUInteger inputBufferCount;
        [Export("inputBufferCount")]
        uint InputBufferCount { get; }
        //@property (nonatomic, readonly) NSUInteger outputBufferCount;
        [Export("outputBufferCount")]
        uint OutputBufferCount { get; }
        //@property (nonatomic, readonly) NSUInteger outputBufferAvailableBytes;
        [Export("outputBufferAvailableBytes")]
        uint OutputBufferAvailableBytes { get; }
        //+ (CBUUID *) brspServiceUUID;
        [Static]
        [Export("brspServiceUUID")]
        CBUUID brspServiceUUID();
        //- (id)initWithPeripheral:(CBPeripheral*)peripheral;
        //[Export("initWithPeripheral:")]
        //void InitWithPeripheral(CBPeripheral periphal);
        [Export("initWithPeripheral:")]
        IntPtr Constructor(CBPeripheral periphal);
        //- (id)initWithPeripheral:(CBPeripheral*)peripheral InputBufferSize:(NSUInteger)in_size OutputBufferSize:(NSUInteger)out_size;
        [Export("initWithPeripheral:InputBufferSize:OutputBufferSize:")]
        //void InitWithPeripheral(CBPeripheral periphal, uint inputBufferSize, uint outputBufferSize);
        IntPtr Constructor(CBPeripheral periphal, uint inputBufferSize, uint outputBufferSize);
        //- (NSError*)changeBrspMode:(BrspMode)mode;
        [Export("changeBrspMode:")]
        NSError ChangeBrspMode(BrspMode mode);
        //- (void)open;
        [Export("open")]
        void Open();
        //- (void)close;
        [Export("close")]
        void Close();
        //- (void)flushInputBuffer;
        [Export("flushInputBuffer")]
        void FlushInputBuffer();
        //- (void)flushInputBuffer:(NSUInteger)byteCount;
        [Export("flushInputBuffer:")]
        void FlushInputBuffer(uint byteCount);
        //- (void)flushOutputBuffer;
        [Export("flushOutputBuffer")]
        void FlushOutputBuffer();
        //- (NSData *)peekBytes:(NSUInteger)byteCount;
        [Export("peekBytes:")]
        NSData PeekBytes(uint byteCount);
        //- (NSString *)peekString:(NSUInteger)byteCount;
        [Export("peekString:")]
        string PeekString(uint byteCount);
        //- (NSData *)peekBytes;
        [Export("peekBytes")]
        NSData PeekBytes();
        //- (NSString *)peekString;
        [Export("peekString")]
        string PeekString();
        //- (NSData *)readBytes:(NSUInteger)byteCount;
        [Export("readBytes:")]
        NSData ReadBytes(uint byteCount);
        //- (NSString *)readString:(NSUInteger)byteCount;
        [Export("readString:")]
        NSString ReadString(uint byteCount);
        //- (NSData *)readBytes;
        [Export("readBytes")]
        string ReadBytes();
        //- (NSString *)readString;
        [Export("readString")]
        string ReadString();
        //- (NSError *)writeBytes:(NSData*)bytes;
        [Export("writeBytes:")]
        NSError WriteBytes(NSData bytes);
        //- (NSError *)writeString:(NSString*)str;
        [Export("writeString:")]
        NSError WriteString(string str);
    }
}

