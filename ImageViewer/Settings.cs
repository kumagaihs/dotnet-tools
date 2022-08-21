using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageViewer {
    public class Settings {
        public class ThumbnailPanelSettings {
            public int height { set; get; }
            public int width { set; get; }
            public int margin { set; get; }
            public Color backgroundColor { set; get; }
            public Boolean subFolderSearch { set; get; }
            public int subFolderDepth { set; get; }
            public Boolean shuffle { set; get; }
        }

        private static Settings self;

        public ThumbnailPanelSettings thumbnailPanelSettings { get; }

        private Settings()
        {
            this.thumbnailPanelSettings = new ThumbnailPanelSettings();
        }

        public static Settings getInstance()
        {
            if (self == null) {
                self = new Settings();
            }
            return self;
        }

    }
}
