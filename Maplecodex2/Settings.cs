using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Maplecodex2
{
    public static class Settings
    {
        public static IConfiguration Configuration { get; set; }

        public static string GetXmlPath()
        {
            return Configuration["XML_PATH"];
        }

        public static Logger InitializeSerilog()
        {
            Log.Logger = Serilog.Config().CreateLogger();
            return Serilog.Config().CreateLogger();
        }

        public static string GetURL()
        {
            return Configuration["USE_URL"];
        }
    }

    // Serilog Settings.
    public static class Serilog
    {
        public static string Template { get; set; } = "{Timestamp:HH:mm:ss} [{Level:u4}]: {Message:lj} {NewLine}" + "{Exception}";

        /// <summary>
        /// Custom configuration for serilog to show on console and save to file.
        /// </summary>
        public static LoggerConfiguration Config()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Override("Default", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Console(theme: Theme.RDKSerilogTheme, outputTemplate: Template)
                .WriteTo.File(Path.Combine("maplecodex2.log"), LogEventLevel.Error);
        }
    }

    // Diferent styles for specific things.
    public static class Theme
    {
        public static CustomConsoleTheme RDKSerilogTheme { get; } = new CustomConsoleTheme();

        public sealed class CustomConsoleTheme : ConsoleTheme
        {
            /// <summary>
            /// True if styling applied by the theme is written into the output, and can thus be
            /// buffered and measured.
            /// </summary>
            public override bool CanBuffer => false;

            /// <summary>
            /// Begin a span of text in the specified <paramref name="style"/>.
            /// </summary>
            /// <param name="output">Output destination.</param>
            /// <param name="style">Style to apply.</param>
            /// <returns></returns>
            protected override int ResetCharCount => 0;

            /// <summary>
            /// Reset the output to un-styled colors.
            /// </summary>
            /// <param name="output">The output.</param>
            public override void Reset(TextWriter output)
            {
                Console.ResetColor();
            }

            // Custom RDK Theme
            /// <summary>
            /// The number of characters written by the <see cref="Reset(TextWriter)"/> method.
            /// </summary>
            public override int Set(TextWriter output, ConsoleThemeStyle style)
            {
                Console.BackgroundColor = ConsoleColor.Black;

                switch (style)
                {
                    case ConsoleThemeStyle.Text:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case ConsoleThemeStyle.SecondaryText:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case ConsoleThemeStyle.TertiaryText:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case ConsoleThemeStyle.Null:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case ConsoleThemeStyle.Number:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case ConsoleThemeStyle.LevelInformation:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case ConsoleThemeStyle.LevelWarning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case ConsoleThemeStyle.LevelError:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case ConsoleThemeStyle.LevelFatal:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    default:
                        break;
                }
                return 0;
            }
        }
    }
}
