using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ContentPipelineExtension.Content;

using TRead = ContentPipelineExtension.Content.ConfigContent;

namespace ContentPipelineExtension
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content
    /// Pipeline to read the specified data type from binary .xnb format.
    /// 
    /// Unlike the other Content Pipeline support classes, this should
    /// be a part of your main game project, and not the Content Pipeline
    /// Extension Library project.
    /// </summary>
    public class ConfigContentReader : ContentTypeReader<TRead>
    {
        protected override TRead Read(ContentReader input, TRead existingInstance)
        {
            ConfigContent content = new ConfigContent();
            content.ConfigName = input.ReadString();
            content.ConfigType = input.ReadString();
            content.ConfigValue = input.ReadString();

            return content;
        }
    }
}
