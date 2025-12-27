using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : class
{
    private readonly ConcurrentDictionary<Guid, T> _storage = new();
    private readonly string _filePath;
    private readonly Func<T, Guid> _getId;

    public CrudServiceAsync(string filePath, Func<T, Guid> getId)
    {
        _filePath = filePath;
        _getId = getId;
    }

    public Task<bool> CreateAsync(T element) =>
        Task.FromResult(_storage.TryAdd(_getId(element), element));

    public Task<T> ReadAsync(Guid id)
    {
        _storage.TryGetValue(id, out var value);
        return Task.FromResult(value);
    }

    public Task<IEnumerable<T>> ReadAllAsync() =>
        Task.FromResult<IEnumerable<T>>(_storage.Values.ToList());

    public Task<IEnumerable<T>> ReadAllAsync(int page, int amount) =>
        Task.FromResult<IEnumerable<T>>(
            _storage.Values.Skip((page - 1) * amount).Take(amount).ToList());

    public Task<bool> UpdateAsync(T element)
    {
        _storage[_getId(element)] = element;
        return Task.FromResult(true);
    }

    public Task<bool> RemoveAsync(T element) =>
        Task.FromResult(_storage.TryRemove(_getId(element), out _));

    public async Task<bool> SaveAsync()
    {
        var json = JsonSerializer.Serialize(_storage.Values, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(_filePath, json);
        return true;
    }

    public IEnumerator<T> GetEnumerator() => _storage.Values.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}
