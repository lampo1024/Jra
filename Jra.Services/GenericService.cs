using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ServiceStack.OrmLite;
using Jra.Dba;

namespace Jra.Services
{
    /// <summary>
    /// 泛型服务抽象类
    /// </summary>
    /// <typeparam name="T">泛型对象</typeparam>
    public abstract class GenericService<T> where T : class, new()
    {
        public virtual T FindById(int id)
        {
            using (var db = DbConnectionFactory.GetDbConnection())
            {
                var entity = db.SingleById<T>(id);
                return entity;
            }
        }

        /// <summary>
        /// 查询所有数据集合
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll()
        {
            using (var db = DbConnectionFactory.GetDbConnection())
            {
                var list = db.Select<T>();
                return list;
            }
        }

        /// <summary>
        /// 根据表达式树条件查询数据集合
        /// </summary>
        /// <param name="predicate">表达式树查询条件</param>
        /// <param name="orderBy">排序字段</param>
        /// <returns></returns>
        public IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "")
        {
            using (var db = DbConnectionFactory.GetDbConnection())
            {
                var expression = db.From<T>();
                if (predicate != null)
                {
                    expression = expression.Where(predicate);
                }
                if (!string.IsNullOrEmpty(orderBy))
                {
                    expression = expression.OrderBy(orderBy);
                }
                var list = db.Select(expression);
                return list;
            }
        }

        /// <summary>
        /// 根据表达式树查询分页数据集合
        /// </summary>
        /// <param name="predicate">表达式树查询条件</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="pageIndex">要查询的页</param>
        /// <param name="pageSize">分页大小,默认:20</param>
        /// <returns></returns>
        public virtual IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderBy = "", int pageIndex = 1, int pageSize = 20)
        {
            using (var db = DbConnectionFactory.GetDbConnection())
            {
                var expression = db.From<T>();
                if (predicate != null)
                {
                    expression = expression.Where(predicate);
                }
                if (!string.IsNullOrEmpty(orderBy))
                {
                    expression = expression.OrderBy(orderBy);
                }
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                expression = expression.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                var entities = db.Select(expression);
                var totalCount = db.Count(predicate);
                var list = new PagedList<T>(entities, pageIndex, pageSize, (int)totalCount);
                return list;
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">泛型实体</param>
        /// <returns></returns>
        public virtual int Insert(T entity)
        {
            using (var db = DbConnectionFactory.GetDbConnection())
            {
                return (int)db.Insert(entity, true);
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">泛型实体</param>
        /// <returns></returns>
        public virtual bool Update(T entity)
        {
            using (var db = DbConnectionFactory.GetDbConnection())
            {
                return db.Update(entity) > 0;
            }
        }

        /// <summary>
        /// 删除数据[注意:彻底删除]
        /// </summary>
        /// <param name="entity">泛型实体</param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            using (var db = DbConnectionFactory.GetDbConnection())
            {
                return db.Delete(entity) > 0;
            }
        }

        /// <summary>
        /// 根据条件删除数据[注意:彻底删除]
        /// </summary>
        /// <param name="where">表达式树查询条件</param>
        /// <returns></returns>
        public virtual bool Delete(Expression<Func<T, bool>> @where)
        {
            using (var db = DbConnectionFactory.GetDbConnection())
            {
                return db.Delete(@where) > 0;
            }
        }
        /// <summary>
        /// 根据实体ID删除对应数据[注意:彻底删除]
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <returns></returns>
        public virtual bool DeleteById(object id)
        {
            using (var db = DbConnectionFactory.GetDbConnection())
            {
                return db.DeleteById<T>(id) > 0;
            }
        }

        /// <summary>
        /// 根据实体ID集合删除对应数据[注意:彻底删除]
        /// </summary>
        /// <param name="ids">实体ID集合</param>
        /// <returns></returns>
        public virtual bool DeleteByIds(object[] ids)
        {
            using (var db = DbConnectionFactory.GetDbConnection())
            {
                return db.DeleteByIds<T>(ids) > 0;
            }
        }
    }
}
