// --------------------------------------------------
// <copyright file="ClassLibrary.cs" company="GMS">
// Copyright (c) GMS. All rights reserved.
// </copyright>
// --------------------------------------------------

namespace DotNet.Framework.Templates
{
    /// <summary>
    /// Represents a class library project template.
    /// </summary>
    public class ClassLibrary : Template
    {
        /// <inheritdoc cref="ClassLibrary"/>
        public ClassLibrary(string name)
            : base(name)
        {
        }

        /// <inheritdoc/>
        public override void Build()
        {
            throw new NotImplementedException();
        }
    }
}
