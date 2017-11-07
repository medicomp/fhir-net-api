﻿/* 
 * Copyright (c) 2017, Furore (info@furore.com) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://github.com/ewoutkramer/fhir-net-api/blob/master/LICENSE
 */

#if NET_FILESYSTEM

using System;
using System.Collections.Generic;

namespace Hl7.Fhir.Specification.Source.Summary
{
    /// <summary>Read-only dictionary interface to access harvested artifact summary properties by key.</summary>
    /// <remarks>
    /// A common interface for both harvester implementation logic and client logic.
    /// Implemented by both <see cref="ArtifactSummaryPropertyBag"/> and <see cref="ArtifactSummary"/>.
    /// This allows <see cref="ArtifactSummaryHarvester"/> implementations to define common property
    /// accessor extension methods that operate on both types, and are available during processing to
    /// other harvesters (providing access to information contained in the property bag that has already
    /// been harvested by preceding delegates) as well as after processing to consumers (providing access
    /// to the final and completed summary).
    /// </remarks>
    public interface IArtifactSummaryPropertyBag : IReadOnlyDictionary<string, object>
    {
    }

    /// <summary>A property bag for storing and retrieving harvested artifact summary information by key.</summary>
    /// <remarks>
    /// The <see cref="ArtifactSummaryGenerator"/> creates a new <see cref="ArtifactSummaryPropertyBag"/>
    /// instance for each artifact and calls the <see cref="ArtifactSummaryHarvester"/> delegates to
    /// harvest summary information into the property bag. Finally, the generator creates a new
    /// <see cref="ArtifactSummary"/> instance from the initialized property bag.
    /// </remarks>
    public class ArtifactSummaryPropertyBag : Dictionary<string, object>, IArtifactSummaryPropertyBag
    {
        public const int DefaultCapacity = 8;

        public ArtifactSummaryPropertyBag() : base(DefaultCapacity) { }
    }
}

#endif