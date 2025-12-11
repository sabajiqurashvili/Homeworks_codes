using BankApp_API.services.Models;
using BankApp_Data;
using BankApp_Domain;
using Microsoft.EntityFrameworkCore;

namespace BankApp_API.services;

public class AccountantService : IAccountantService
{
    private readonly BankAppContext _context;

    public AccountantService(BankAppContext context) => _context = context;
    
    public async Task<List<Loan>> SeeLoans(int userId)
    {
        if( !await _context.Users.AnyAsync(u => u.Id == userId)) throw new Exception("User not found");
        var loans = await _context.Loans.Where(l => l.UserId == userId).ToListAsync();
        return loans;
    }

    public async Task<Loan> UpdateLoan(int userId, int loanId, LoanDtoForAccountant loanDto)
    {
        if( !await _context.Users.AnyAsync(u => u.Id == userId)) throw new Exception("User not found");
        if(!await _context.Loans.Where(l => l.UserId == userId).AnyAsync(l => l.Id == loanId)) throw new Exception("Loan not found");
        var loan = await _context.Loans.FirstOrDefaultAsync(u => u.Id == userId && u.Id == loanId);
        if(loan == null) throw new Exception("Loan does not exist");
        loan.Status = loanDto.Status;
        _context.Loans.Update(loan);
        await _context.SaveChangesAsync();
        return loan;
    }

    public async Task DeleteLoan(int userId, int loanId)
    {
        if( !await _context.Users.AnyAsync(u => u.Id == userId)) throw new Exception("User not found");
        if(!await _context.Loans.Where(l => l.UserId == userId).AnyAsync(l => l.Id == loanId)) throw new Exception("Loan not found");
        var loan = await _context.Loans.FirstOrDefaultAsync(l => l.UserId == userId && l.Id == loanId);
        if(loan == null) throw new Exception("Loan doesn't exist");
        _context.Loans.Remove(loan);
        await _context.SaveChangesAsync();
        
    }

    public async Task BlockUser(int userId)
    {
        if( !await _context.Users.AnyAsync(u => u.Id == userId)) throw new Exception("User not found");
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if(user == null) throw new Exception("User doesn't exist");
        user.IsBlocked = true;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}