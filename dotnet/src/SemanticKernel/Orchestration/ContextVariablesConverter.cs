﻿// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.SemanticKernel.Orchestration;

/// <summary>
/// Converter for <see cref="ContextVariables"/> to/from JSON.
/// </summary>
public class ContextVariablesConverter : JsonConverter<ContextVariables>
{
    /// <summary>
    /// Read the JSON and convert to ContextVariables
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The type to convert from.</param>
    /// <param name="options">The JSON serializer options.</param>
    /// <returns>The deserialized <see cref="ContextVariables"/>.</returns>
    public override ContextVariables Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Needs Test
        var keyValuePairs = JsonSerializer.Deserialize<IEnumerable<KeyValuePair<string, string>>>(ref reader, options);
        var context = new ContextVariables();

        foreach (var kvp in keyValuePairs!)
        {
            context.Set(kvp.Key, kvp.Value);
        }

        return context;
    }

    public override void Write(Utf8JsonWriter writer, ContextVariables value, JsonSerializerOptions options)
    {
        // Needs Test
        JsonSerializer.Serialize(writer, value, options);
    }
}
