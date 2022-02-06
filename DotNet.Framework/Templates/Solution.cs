// --------------------------------------------------
// <copyright file="Solution.cs" company="GMS">
// Copyright (c) GMS. All rights reserved.
// </copyright>
// --------------------------------------------------

using System.Collections.ObjectModel;
using DotNet.Framework.Contracts;
using DotNet.Framework.Options;

namespace DotNet.Framework.Templates
{
    /// <summary>
    /// Represents a solution project template.
    /// </summary>
    public class Solution : Template
    {
        private readonly ICollection<ITemplate> _templates;

        /// <inheritdoc cref="Solution"/>
        public Solution(string name)
            : base(name)
        {
            _templates = new Collection<ITemplate>();
        }

        /// <summary>
        /// Gets or sets the solution options template will use to be built.
        /// </summary>
        public SolutionOptions Options { get; protected set; } = new SolutionOptions();

        /// <summary>
        /// Adds project templates to the current solution.
        /// </summary>
        /// <param name="template">The project template to be added.</param>
        /// <returns>The solution with the added template.</returns>
        public Solution AddTemplate(ITemplate template)
        {
            _templates.Add(template);
            return this;
        }

        /// <summary>
        /// Allows a set of options while return the current solution.
        /// </summary>
        /// <param name="options">The options to be set.</param>
        /// <returns>The solution with the options set.</returns>
        public Solution SetOptions(SolutionOptions options)
        {
            Options = options;
            return this;
        }

        /// <summary>
        /// Removes project templates to the current solution.
        /// </summary>
        /// <param name="template">The project template to be removed.</param>
        /// <returns>The solution with the removed template.</returns>
        public Solution RemoveTemplate(ITemplate template)
        {
            ITemplate? removingTemplate = _templates.FirstOrDefault(t => t.Name == template.Name);

            if (removingTemplate != null)
                _templates.Remove(template);

            return this;
        }

        /// <inheritdoc/>
        public override void Build()
        {
            var process = new DotNetProcess();
            process
                .AddArgument("new")
                .AddArgument("sln")
                .Run();
        }
    }
}
