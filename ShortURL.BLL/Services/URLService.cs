using AutoMapper;
using ShortURL.BLL.Interfaces;
using ShortURL.BLL.Models;
using ShortURL.DAL.Interfaces;
using ShortURL.DAL.Models;

namespace ShortURL.BLL.Services
{
    public class URLService : IURLService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public URLService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(URL request)
        {
            request.CreatedDate = DateTime.Now;
            request.ShortURL = UrlShortener.ShortenUrl(request.OriginalURL);

            await _unitOfWork.URLs.CreateAsync(_mapper.Map<URL, URLEntity>(request));
        }

        public async Task DeleteAllAsync()
        {
            var request = await _unitOfWork.URLs.GetAllAsync();

            foreach (var item in request)
            {
                await _unitOfWork.URLs.DeleteAsync(item.Id);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.URLs.DeleteAsync(id);
        }

        public async Task<IEnumerable<URL>> GetAllAsync()
        {
            var request = await _unitOfWork.URLs.GetAllAsync();

            return _mapper.Map<IEnumerable<URLEntity>, IEnumerable<URL>>(request);
        }

        public async Task<URL> GetAsync(int id)
        {
            var request = await _unitOfWork.URLs.GetAsync(id);

            return _mapper.Map<URLEntity, URL>(request);
        }
    }
}
