using System.Collections.Generic;

namespace REghZyWPFLib.Core.Menus {
    public interface IContextProvider {
        IEnumerable<IContext> ProvideContext();
    }
}