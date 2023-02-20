using System;

namespace REghZyWPFLib.Core.Dialogs {
    public class ValidationFailedException : Exception {
        public string Caption { get; set; }

        public ValidationFailedException(string caption, string message) : base(message ?? caption ?? "Information") {
            this.Caption = caption ?? "Information";
        }
    }
}