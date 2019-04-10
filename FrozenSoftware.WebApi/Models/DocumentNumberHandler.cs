using FrozenSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrozenSoftware.WebApi.Models
{
    public class DocumentNumberHandler
    {
        private static DocumentNumberHandler documentNumberHandler;

        private Dictionary<Guid, DocumentNumber> reservedDocumentNumbers;

        private const string DayFormat = "DD";
        private const string MonthFormat = "MM";
        private const string YearFormat = "YYYY";

        public static DocumentNumberHandler Instance
        {
            get
            {
                if (documentNumberHandler == null)
                    documentNumberHandler = new DocumentNumberHandler();

                return documentNumberHandler;
            }
        }

        public void SetReservedDocumentNumbers(Dictionary<Guid, DocumentNumber> testReservedDocumentNumbers)
        {
            reservedDocumentNumbers = testReservedDocumentNumbers;
        }

        public int? Save(Guid reserverdNumberKey)
        {
            bool hasReservedNumber = reservedDocumentNumbers.ContainsKey(reserverdNumberKey);

            if (!hasReservedNumber)
                return null;

            DocumentNumber docNumber = reservedDocumentNumbers[reserverdNumberKey];
            int docNumberId;
            using (FrozenSoftwareWebApiContext context = new FrozenSoftwareWebApiContext())
            {
                context.DocumentNumbers.Add(docNumber);
                context.SaveChanges();
                docNumberId = docNumber.Id;
            }

            reservedDocumentNumbers.Remove(reserverdNumberKey);

            return docNumberId;
        }

        public (string ErrorMessage, DocumentNumber DocNumber) ReserverdDocumentNumber(Guid guid, int documentNumberDefinitionId, DateTime documentDate)
        {
            if (reservedDocumentNumbers.ContainsKey(guid))
                return ("_The key is taken. Please Try again.", null);

            DocumentNumber reserverdDocumentNumber = new DocumentNumber()
            {
                DocumentNumberDefinitionId = documentNumberDefinitionId,
                CreatedDate = DateTime.UtcNow,
                DocumentDate = documentDate,
            };

            using (FrozenSoftwareWebApiContext context = new FrozenSoftwareWebApiContext())
            {
                DocumentNumberDefinition documentNumberDefinition = context.DocumentNumberDefinitions.Find(documentNumberDefinitionId);
                if (documentNumberDefinition == null)
                    return ("_Don't find Document Number Definition with provided key.", null);

                if (documentNumberDefinition.HasDate)
                    ProcessNumberWithDate(reserverdDocumentNumber, documentDate, context, documentNumberDefinition);
                else
                {

                }

            }

            return (null, reserverdDocumentNumber);
        }

        private void ProcessNumberWithDate(DocumentNumber reserverdDocNumb, DateTime documentDate, FrozenSoftwareWebApiContext context, DocumentNumberDefinition docNumDef)
        {
            List<DocumentNumber> alldocNumbers = new List<DocumentNumber>();
            alldocNumbers = context.DocumentNumbers.Where(x => x.DocumentNumberDefinitionId == docNumDef.Id && x.DocumentDate == documentDate).ToList();
            List<DocumentNumber> reservedDocNumber = reservedDocumentNumbers.Values.Where(x => x.DocumentNumberDefinitionId == docNumDef.Id && x.DocumentDate == documentDate).ToList();

            if (reservedDocNumber != null && reservedDocNumber.Count > 0)
                alldocNumbers.AddRange(reservedDocNumber);

            alldocNumbers = alldocNumbers.OrderByDescending(x => x).ToList();

            string dateFormat = null;

            dateFormat = docNumDef.DateFormat.ToUpper();

            if (dateFormat.Contains(DayFormat))
            {
                int documetDay = documentDate.Day;
                dateFormat = dateFormat.Replace(DayFormat, documetDay.ToString("D2"));
                reserverdDocNumb.Day = documetDay;
            }

            if (dateFormat.Contains(MonthFormat))
            {
                int documetMonth = documentDate.Month;
                dateFormat = dateFormat.Replace(DayFormat, documetMonth.ToString("D2"));
                reserverdDocNumb.Month = documetMonth;
            }

            if (dateFormat.Contains(YearFormat))
            {
                int documetYear = documentDate.Year;
                string yearText = documetYear.ToString();
                dateFormat = dateFormat.Replace(DayFormat, yearText);
                reserverdDocNumb.Year = documetYear;
                reserverdDocNumb.YearLenght = yearText.Length;
            }

            int number = 1;

            if (alldocNumbers.Count > 0)
                number = alldocNumbers.Max(x => x.Number) + 1;

            reserverdDocNumb.Number = number;
            reserverdDocNumb.DocumentNumberText = reserverdDocNumb.FormatNumber(docNumDef, dateFormat);
        }

        private DocumentNumberHandler()
        {
            reservedDocumentNumbers = new Dictionary<Guid, DocumentNumber>();
        }
    }
}