using System;
using System.Collections.Generic;

namespace Kefir.ShaderColorEditor.Model
{
    internal class ColorEditorMode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorEditorMode" /> class.
        /// </summary>
        /// <param name="name">The display name.</param>
        /// <param name="xyShader">The shader to be used on XY color plane.</param>
        /// <param name="zShader">The shader to be used on color slider.</param>
        public ColorEditorMode(string name, string xyShader, string zShader)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(xyShader) || string.IsNullOrEmpty(zShader))
            {
                throw new ArgumentNullException();
            }

            _name = name;
            _xyShader = xyShader;
            _zShader = zShader;
        }

        public string Name
        {
            get { return _name; }
        }

        public string XyShader
        {
            get { return _xyShader; }
        }
        public string ZShader
        {
            get { return _zShader; }
        }

        public static IEnumerable<ColorEditorMode> GetAllModes()
        {
            yield break;
        }

        private readonly string _name;
        private readonly string _xyShader;
        private readonly string _zShader;
    }
}
