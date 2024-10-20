using School_Managment_System1.Entities;
using School_Managment_System1.Repositories;

namespace School_Managment_System1.InterFaces.IRepositories
{
    public interface IStudentsTrimestsRatesService : IRepository<StudensTrimestRate>
    {
        Task<StudensTrimestRate> GetByIdAsync(int studentTrimestRateId);
        Task<IEnumerable<StudensTrimestRate>> GetByStudentIDPerTrimestAsync(int StudentID, int trimest);
        Task<IEnumerable<StudensTrimestRate>> GetByStudentIDPerTrimestAsync(int StudentID, int trimest, int year);
        Task<IEnumerable<StudensTrimestRate>> GetByStudentIDAsync(int StudentID);
        Task<IEnumerable<StudensTrimestRate>> GetByStartYearAsync(int StartYear);
        Task<IEnumerable<StudensTrimestRate>> GetByEndYearAsync(int EndYear);
        Task<IEnumerable<StudensTrimestRate>> GetByStudentIDPerSubjectPerTrimesAsync(int StudentID, int trimest, int subject);
        Task<StudensTrimestRate> GetByStudentIDPerSubjectPerTrimesAsync(int StudentID, int trimest, int subjectID, int StartYear);
        Task<StudensTrimestRate> GetByStudentIDPerSubjectPerTrimesAsync(int StudentID, int trimest, string subjectName, int StartYear);
        Task<IEnumerable<StudensTrimestRate>> GetByStudentIDPerSubjectInAllTrimestsAsync(int StudentID, int subjectID);

    }

}
