using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHMS.Models;
using SHMS.Data;

public class TestResultService
{
    private readonly DataContext _context;

    public TestResultService(DataContext context)
    {
        _context = context;
    }

    // Save test result (Doctor uploads it)
    public async Task<TestResult> AddTestResultAsync(TestResult testResult)
    {
        _context.TestResults.Add(testResult);
        await _context.SaveChangesAsync( );
        return testResult;
    }

    // Get all test results for a patient
    public async Task<List<TestResult>> GetPatientTestResultsAsync(int patientId)
    {
        return await _context.TestResults
            .Where(tr => tr.PatientId == patientId)
            .OrderByDescending(tr => tr.CreatedAt)
            .ToListAsync( );
    }
}
