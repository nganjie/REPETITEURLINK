using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace REPETITEURLINK.Services.JsonExtensions;



public sealed class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        // Première passe : compter les underscores à insérer
        int additionalChars = 0;

        for (int i = 1; i < name.Length; i++)
        {
            if (char.IsUpper(name[i]) && !char.IsUpper(name[i - 1]))
            {
                additionalChars++;
            }
        }

        if (additionalChars == 0)
            return name.ToLowerInvariant();

        // Allocation finale unique
        return string.Create(
            name.Length + additionalChars,
            name,
            static (span, source) =>
            {
                int pos = 0;

                for (int i = 0; i < source.Length; i++)
                {
                    char c = source[i];

                    if (char.IsUpper(c))
                    {
                        if (i > 0 && !char.IsUpper(source[i - 1]))
                        {
                            span[pos++] = '_';
                        }

                        span[pos++] = char.ToLowerInvariant(c);
                    }
                    else
                    {
                        span[pos++] = c;
                    }
                }
            });
    }
}

