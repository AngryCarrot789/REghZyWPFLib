using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REghZyWPFLib.Core;

namespace REghZyWPFLib.Example {
    public static class IoC {
        public static SimpleIoC Instance { get; } = new SimpleIoC();
    }
}
