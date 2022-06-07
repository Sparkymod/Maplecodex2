using Microsoft.AspNetCore.Components;

namespace Maplecodex2.Components.Spinkit
{
    public partial class Spinner
    {
        [Parameter] public string CustomCss { get; set; } = string.Empty;
        [Parameter] public SpinnerType SpinnerType { get; set; } = SpinnerType.Circle;
    }

    public enum SpinnerType
    {
        Circle,
        FadeCircle,
        GridCube,
        FoldingCube,
    }
}
