using simplePdfConverter.Contracts.Bootstrappers;

namespace simplePdfConverter.Contracts
{
    public class ShellMenuItem
    {
        public string Caption { get; set; }
        public IScreenViewModel ScreenViewModel { get; set; }
    }
}
