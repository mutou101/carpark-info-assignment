using CsvHelper;
using System.Globalization;
using carpark_info_assignment.Models;

namespace carpark_info_assignment.Business
{
    public class CsvService
    {
        public List<Carpark> ReadCsvFile(Stream stream)
        {
            try
            {
                using var reader = new StreamReader(stream);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Context.RegisterClassMap<CarparkMap>();
                var records = csv.GetRecords<Carpark>().ToList();
                return records;

            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FieldValidationException e)
            {
                throw new Exception(e.Message);
            }
            catch (CsvHelperException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}