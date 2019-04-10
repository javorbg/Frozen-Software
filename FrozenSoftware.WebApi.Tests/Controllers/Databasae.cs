using FrozenSoftware.Models;
using System;
using System.Collections.Generic;

namespace FrozenSoftware.WebApi.Tests.Controllers
{
    public class Databasae
    {

        /// <summary>
        /// Empty Document Numbers
        /// </summary>
        /// <returns></returns>
        public static List<DocumentNumber> EmptyDocumentNumberTest()
        {
            List<DocumentNumber> documentNumbers = new List<DocumentNumber>();

            return documentNumbers;
        }

        public static Dictionary<Guid, DocumentNumber> EmptyDocumentNumberHandlerDict()
        {
            Dictionary<Guid, DocumentNumber> documentNumbers = new Dictionary<Guid, DocumentNumber>();

            return documentNumbers;
        }

        public static List<DocumentNumberDefinition> NotEmptyDcumentDefinition()
        {
            List<DocumentNumberDefinition> documentNumberDefinitions = new List<DocumentNumberDefinition>();
            DateTime date = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            documentNumberDefinitions.Add(new DocumentNumberDefinition()
            {
                Id = 1,
                StartDate = date,
                EndDate = date.AddMonths(12),
                HasDate = false,
                Name = "Test",
                NumberPosition = 1,
                NumbersCount = 6,
            });

            return documentNumberDefinitions;
        }
    }
}
