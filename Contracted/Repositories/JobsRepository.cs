using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;
using GroupMe.Models;

namespace Contracted.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;
        public  JobsRepository(IDbConnection db)
        {
            _db = db;
        }
        public List<Job> GetAll()
        {
            string sql = @"
            SELECT 
            j.*,
            a.*
            FROM job j
            JOIN Accounts a On j.creatorId = a.id
            ";
            return _db.Query<Job, Profile, Job>(sql, (j, p) =>
            {
                j.CreatorId = p.Id;
                return j;
            }, splitOn: "id").ToList();
        }
        public Job Create(Job data)
        {
            var sql = @"
                INSERT INTO job(name, description, creatorId)
                VALUES(@Name, @Description, @CreatorId);
                SELECT LAST_INSERT_ID();
                ";
               var id = _db.ExecuteScalar<int>(sql, data);
               data.Id = id;
               return data;

        }

        internal void Remove(int id)
        {
            string sql = "DELETE FROM job WHERE id = @Id LIMIT 1;";
                _db.Execute(sql, new {id});
        }
        public Job GetById(int id)
        {
            string sql = @"
            SELECT j.*,
                    a.*
                    FROM job j
                    JOIN Accounts a ON r.creatorId = a.id
                    WHERE j.id = @id;
                    ";
                    return _db.Query<Job, Profile, Job>(sql, (j,p) =>
                    {
                        j.CreatorId = p.Id;
                        return j;
                    }, new {id}).FirstOrDefault();
                    }
            
        }
    }
