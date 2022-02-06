// --------------------------------------------------
// <copyright file="Template.cs" company="GMS">
// Copyright (c) GMS. All rights reserved.
// </copyright>
// --------------------------------------------------

using DotNet.Framework.Contracts;

namespace DotNet.Framework.Templates
{
    /// <summary>
    /// Attaches the common funcitonalities of a template.
    /// </summary>
    public abstract class Template : ITemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Template"/> class.
        /// </summary>
        /// <param name="name">The name of template.</param>
        internal Template(string name)
        {
            Name = name;
        }

        /// <inheritdoc/>
        public string Name { get; internal set; } = default!;

        /// <inheritdoc/>
        public abstract void Build();
    }
}
