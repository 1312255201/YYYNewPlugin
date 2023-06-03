using System.ComponentModel;

namespace YYYNewPlugin
{
    public class Config
    {
        [Description("是否开启Debug")]
        public bool Debug { get; set; } = true;
    }
}