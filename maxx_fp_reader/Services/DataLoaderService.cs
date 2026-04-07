using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maxx_pos.Models;

namespace maxx_pos.Services
{
    public class DataLoaderService
    {
        private readonly ApiService apiService;

        public DataLoaderService(string token)
        {
            apiService = new ApiService(token);
        }

        public async Task<List<string>> LoadDepartmentsAsync(bool includeInactive = false)
        {
            var response = await apiService.GetAsync<DepartmentResponse>("get-department");

            if (response?.data == null || response.data.Count == 0)
                return new List<string>();

            var departments = response.data.AsQueryable();

            if (!includeInactive)
                departments = departments.Where(d => d.is_deleted == 0 && d.inactived == "No");

            return departments.Select(d => d.description).Prepend(string.Empty).ToList();
        }

        public async Task<List<string>> LoadCategoriesAsync(bool includeInactive = false)
        {
            var response = await apiService.GetAsync<CategoryResponse>("get-category");

            if (response?.data == null || response.data.Count == 0)
                return new List<string>();

            var categories = response.data.AsQueryable();

            if (!includeInactive)
                categories = categories.Where(d => d.is_deleted == 0 && d.inactived == "No");

            return categories.Select(d => d.description).Prepend(string.Empty).ToList();
        }

        public async Task<List<Department>> LoadDepartmentObjectsAsync(bool includeInactive = false)
        {
            var response = await apiService.GetAsync<DepartmentResponse>("get-department");

            if (response?.data == null || response.data.Count == 0)
                return new List<Department>();

            if (!includeInactive)
                return response.data.Where(d => d.is_deleted == 0 && d.inactived == "No").ToList();

            return response.data;
        }

        public async Task<List<string>> LoadBranchesAsync()
        {
            var response = await apiService.GetAsync<BranchResponse>("get-branch");

            if (response?.data == null || response.data.Count == 0)
                return new List<string>();

            return response.data.Select(b => b.description).ToList();
        }
    }
}