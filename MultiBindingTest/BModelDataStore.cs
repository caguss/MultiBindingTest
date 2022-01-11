using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MultiBindingTest
{
    public class BModelDataStore : IDataStore<BModel>
    {
        private List<BModel> items;

        /// <summary>
        /// 화학물질/msds/비상대응 데이터 맞추어 넣기?
        /// </summary>
        public BModelDataStore()
        {
            GetRefresh();
        }

        public async Task<bool> AddItemAsync(BModel item)
        {
            items.Add(item);

            //Provider를 통한 데이터 입력

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(BModel item)
        {
            var oldItem = items.Where((BModel arg) => arg.Name == item.Name).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((BModel arg) => arg.Name == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<BModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Name == id));
        }

        public async Task<IEnumerable<BModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public void GetRefresh()
        {
            //Provider를 통한 데이터 조회
            items = new List<BModel>()
            {

                new BModel { Name ="Name1",Jayce = Guid.NewGuid().ToString(), Rumble = "First item"},
                new BModel { Name ="Name2",Jayce = Guid.NewGuid().ToString(), Rumble = "Second item" },
                new BModel { Name ="Name3",Jayce = Guid.NewGuid().ToString(), Rumble = "Third item"},
                new BModel { Name ="Name4",Jayce = Guid.NewGuid().ToString(), Rumble = "Fourth item" },
                new BModel { Name ="Name5",Jayce = Guid.NewGuid().ToString(), Rumble = "Fifth item"},
                new BModel { Name ="Name6",Jayce = Guid.NewGuid().ToString(), Rumble = "Sixth item"}
            };
        }
    }

}