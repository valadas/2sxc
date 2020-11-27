﻿using ToSic.Sxc.Cms.Publishing;

// ReSharper disable once CheckNamespace
namespace ToSic.Eav.Context
{
    public interface IContextOfBlock: IContextOfSite
    {
        /// <summary>
        /// The page it's running on + parameters for queries, url etc.
        /// </summary>
        IPage Page { get; }

        /// <summary>
        /// The container for our block, basically the module
        /// </summary>
        IModule Module { get; }

        /// <summary>
        /// Publishing information about the current context
        /// </summary>
        BlockPublishingState Publishing { get; }
    }
}
