using BO;
using BO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class WatercolorsPaintingDAO
    {
        private readonly WatercolorsPainting2024DBContext _context;
        private static WatercolorsPaintingDAO instance;
        public static WatercolorsPaintingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WatercolorsPaintingDAO();
                }
                return instance;
            }
        }

        public WatercolorsPaintingDAO()
        {
            if (_context == null)
                _context = new WatercolorsPainting2024DBContext();
        }

        public async Task<List<WatercolorsPainting>> GetAll()
        {
            return await _context.WatercolorsPaintings.Include(x => x.Style).ToListAsync();
        }

        public async Task<WatercolorsPainting> GetById(string id)
        {
            return await _context.WatercolorsPaintings.Include(x => x.Style).FirstOrDefaultAsync(x => x.PaintingId.Equals(id));
        }

        public async Task<ResultData> Delete(string id)
        {
            try
            {
                WatercolorsPainting paint = await _context.WatercolorsPaintings.FirstOrDefaultAsync(x => x.PaintingId.Equals(id));
                if (paint == null)
                    return new ResultData { StatusCode = -1, Message = "Cannot find painting" };

                _context.WatercolorsPaintings.Remove(paint);
                await _context.SaveChangesAsync();
                return new ResultData();
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                return new ResultData { StatusCode = -1, Message = ex.Message };
            }
            finally
            {
                _context.ChangeTracker.Clear();
            }
        }

        public async Task<ResultData> Create(WatercolorsPaintingDTO paint)
        {
            try
            {
                WatercolorsPainting currentPaint = await _context.WatercolorsPaintings.FirstOrDefaultAsync(x => x.PaintingId.Equals(paint.PaintingId));
                if (currentPaint != null) 
                    return new ResultData { StatusCode = -1, Message = "Painting has already existed!"};

                WatercolorsPainting newPaint = new WatercolorsPainting()
                {
                    PaintingId = paint.PaintingId,
                    CreatedDate = DateTime.Now,
                    PaintingAuthor = paint.PaintingAuthor,
                    PaintingDescription = paint.PaintingDescription,
                    PaintingName = paint.PaintingName,
                    Price = paint.Price,
                    PublishYear = paint.PublishYear,
                    StyleId = paint.StyleId,
                };

                _context.WatercolorsPaintings.Add(newPaint);
                await _context.SaveChangesAsync();
                return new ResultData();
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                return new ResultData { StatusCode = -1, Message = ex.Message };
            }
            finally
            {
                _context.ChangeTracker.Clear();
            }
        }

        public async Task<ResultData> Update(string id, UpdateWatercolorsPaintingDTO paint)
        {
            try
            {
                WatercolorsPainting updatedPaint = await _context.WatercolorsPaintings.FirstOrDefaultAsync(x => x.PaintingId.Equals(id));
                if (updatedPaint == null) 
                    return new ResultData { StatusCode = -1, Message = "Cannot find painting" };

                updatedPaint.PaintingName = paint.PaintingName;
                updatedPaint.PaintingDescription = paint.PaintingDescription;
                updatedPaint.PaintingAuthor = paint.PaintingAuthor;
                updatedPaint.Price = paint.Price;
                updatedPaint.PublishYear = paint.PublishYear;
                updatedPaint.StyleId = paint.StyleId;

                _context.Update(updatedPaint);
                await _context.SaveChangesAsync();
                return new ResultData();
            }
            catch (Exception ex)
            {
                return new ResultData { StatusCode = -1, Message = ex.Message };
            }
            finally
            {
                _context.ChangeTracker.Clear();
            }
        }

        public async Task<List<WatercolorsPainting>> Search(string searchValue)
        {
            return await _context.WatercolorsPaintings
                .Include(x => x.Style)
                .Where(x => x.PublishYear.ToString().Contains(searchValue.ToString()) ||
                            x.PaintingAuthor.Contains(searchValue)).ToListAsync();
        }
    }
}
