using System;
using System.Text;
using Apps.DataClient.Core;
using System.Collections.Generic;

namespace School.People.App
{
    /// <summary>
    /// Provides mapping support for outbound and
    /// inbound data identifiers.
    /// </summary>
    public class IdentifierMapping : IIdentifierMapping
    {
        /// <summary>
        /// Gets a mapped Id.
        /// </summary>
        /// /// <param name="id">Lookup key Id..</param>
        /// <returns>[Guid] if one exists, otherwise null.</returns>
        public Guid Get(Guid id)
        {
            if (id == Guid.Empty) { return id; }
            var builder = new StringBuilder(id.ToString());
            for (int i = 0; i < builder.Length; i++)
            {
                builder[i] = ReadingKeys[builder[i]];
            }
            return new Guid(builder.ToString());
        }

        /// <summary>
        /// Creates a new Id mapping.
        /// </summary>
        /// <param name="id">Id to be mapped.</param>
        /// <returns>Key Id of the newly created mapping.</returns>
        public Guid Create(Guid id)
        {
            if (id == Guid.Empty) { return id; }
            var builder = new StringBuilder(id.ToString());
            for (int i = 0; i < builder.Length; i++)
            {
                builder[i] = WritingKeys[builder[i]];
            }
            return new Guid(builder.ToString());
        }

        private void BuildReadWriteKeys()
        {
            var rnd = new Random();
            var hexes = "0123456789abcdef";
            var shuffled = new char[16] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            WritingKeys.Add('-', '-');
            ReadingKeys.Add('-', '-');
            for (int i = 0; i < 16; i++)
            {
                var index = rnd.Next(0, 15);
                var hold = shuffled[i];
                shuffled[i] = shuffled[index];
                shuffled[index] = hold;
            }
            for (int i = 0; i < 16; i++)
            {
                WritingKeys.Add(hexes[i], shuffled[i]);
                ReadingKeys.Add(shuffled[i], hexes[i]);
            }
        }

        public IdentifierMapping() => BuildReadWriteKeys();

        private readonly Dictionary<char, char> WritingKeys = new Dictionary<char, char>();
        private readonly Dictionary<char, char> ReadingKeys = new Dictionary<char, char>();
    }
}