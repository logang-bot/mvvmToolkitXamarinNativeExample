using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedCode.Model;
using SharedCode.Services;

namespace SharedCode.Repository
{
	public interface IUserRepository
	{
		Task<List<User>> GetUsersFromNetwork();
		Task<List<Post>> GetPostsFromNetwork();
		Task<User> GetSingleUser();
		Task<Post> GetSinglePost();
	}
	public class UserRepository : IUserRepository
	{
		private readonly INetworkService networkService;
		public UserRepository(INetworkService netService)
		{
			this.networkService = netService;
		}

        public async Task<List<User>> GetUsersFromNetwork()
        {
            try
			{
				var users = await networkService.GetData<List<User>>("https://jsonplaceholder.typicode.com/users");
				return users;
			} catch (Exception e)
			{
				Console.WriteLine(e);
				return new List<User>();
			}
        }


        public async Task<List<Post>> GetPostsFromNetwork()
        {
            try
            {
                var posts = await networkService.GetData<List<Post>>("https://jsonplaceholder.typicode.com/posts");
                return posts;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Post>();
            }
        }

		public async Task<User> GetSingleUser()
		{
			try
			{
				var user = await networkService.GetData<User>("https://jsonplaceholder.typicode.com/users/2");
				return user;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw e;
			}
		}

		public async Task<Post> GetSinglePost()
		{
			try
			{
				var post = await networkService.GetData<Post>("https://jsonplaceholder.typicode.com/posts/3");
				return post;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw e;
			}
		}
    }
}

