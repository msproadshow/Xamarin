﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace FormsVSNative.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate // global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        public override UIWindow Window
        {
            get; set;
        }
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //global::Xamarin.Forms.Forms.Init();
            //LoadApplication(new App());



            //return base.FinishedLaunching(app, options);

            return true;
        }
    }
}
