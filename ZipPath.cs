using System.Collections;
using System.IO.Compression;
using System.Reflection.Metadata;

public class ZipPath : ICloneable
{
    internal string[] _path;

    public ZipPath(string path) => _path = path.Split(['\\', '/']);

    public ZipPath(IList<string> path) => _path = path.ToArray();

    public bool IsFile => !string.Equals(FileName, "", StringComparison.OrdinalIgnoreCase);

    public bool IsFolder => !IsFile;

    public string FileName => _path[^1];

    public string FileNameWithoutExtension => Path.GetFileNameWithoutExtension(FileName);

    public string Extension => Path.GetExtension(FileName);

    public ZipPath ParentDirectory
    {
        get
        {
            if (_path.Length == 1) return new ZipPath([""]);
            if (IsFolder && _path.Length == 2) return new ZipPath([""]);
            return new ZipPath([.. _path[0..^1], ""]);
        }
    }

    public bool IsWithinFolder(ZipPath zipFolder)
    {
        if (zipFolder.IsFile) return false;
        return zipFolder == ParentDirectory;
    }

    public override string ToString() => string.Join('/', _path);

    public override int GetHashCode() => (_path as IStructuralEquatable).GetHashCode(StringComparer.OrdinalIgnoreCase);

    public override bool Equals(object obj) => Equals(obj as ZipPath);

    public bool Equals(ZipPath obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (GetType() != obj.GetType()) return false;
        if (_path.Length != obj._path.Length) return false;

        return _path.SequenceEqual(obj._path, StringComparer.OrdinalIgnoreCase);
    }

    public object Clone() => new ZipPath(ToString());

    public static bool operator ==(ZipPath lhs, ZipPath rhs)
    {
        if (lhs is null && rhs is null) return true;
        if (lhs is null || rhs is null) return false;
        return lhs.Equals(rhs);
    }

    public static bool operator !=(ZipPath lhs, ZipPath rhs) => !(lhs == rhs);
}