using Microsoft.EntityFrameworkCore;
using SPSS.Repository.Interfaces;
using SPSS.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSS.BusinessObject.Models;
using SPSS.BusinessObject.Context;

namespace SPSS.Repository.Implementations;

public class ChatHistoryRepository : RepositoryBase<ChatHistory, Guid>, IChatHistoryRepository
{
    public ChatHistoryRepository(UserDBContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ChatHistory>> GetByUserIdAsync(Guid userId, int limit = 100)
    {
        return await Entities
            .Where(ch => ch.UserId == userId && !ch.IsDeleted)
            .OrderByDescending(ch => ch.Timestamp)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<IEnumerable<ChatHistory>> GetBySessionIdAsync(string sessionId)
    {
        return await Entities
            .Where(ch => ch.SessionId == sessionId && !ch.IsDeleted)
            .OrderBy(ch => ch.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<ChatHistory>> GetRecentSessionsAsync(Guid userId, int maxSessions = 10)
    {
        // Get distinct session IDs for the user, ordered by the most recent message in each session
        var recentSessionIds = await Entities
            .Where(ch => ch.UserId == userId && !ch.IsDeleted)
            .GroupBy(ch => ch.SessionId)
            .OrderByDescending(g => g.Max(ch => ch.Timestamp))
            .Select(g => g.Key)
            .Take(maxSessions)
            .ToListAsync();

        // Get all messages from these sessions
        return await Entities
            .Where(ch => recentSessionIds.Contains(ch.SessionId) && !ch.IsDeleted)
            .OrderBy(ch => ch.SessionId)
            .ThenBy(ch => ch.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<ChatHistory>> GetByUserIdAndSessionIdAsync(Guid userId, string sessionId)
    {
        return await Entities
            .Where(ch => ch.UserId == userId && ch.SessionId == sessionId && !ch.IsDeleted)
            .OrderBy(ch => ch.Timestamp)
            .ToListAsync();
    }
}