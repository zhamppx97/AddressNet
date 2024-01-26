## AddressNet

Minimal library to retrieve addresses in countries.

## Benchmark
``` ini

BenchmarkDotNet v0.13.12,
[Host]    : .NET 6.0.26 (6.0.2623.60508), X64 RyuJIT AVX2 [AttachedDebugger]
MediumRun : .NET 6.0.26 (6.0.2623.60508), X64 RyuJIT AVX2


```
| Method                     | Mean       | Error      | StdDev     | Gen0    | Allocated |
|--------------------------- |-----------:|-----------:|-----------:|--------:|----------:|
| GetAllAddress              |   7.544 us |  0.6302 us |  0.9238 us | 28.5645 |   60032 B |
| GetByPostalCode            |  44.804 us |  8.9618 us | 12.8527 us |  0.1221 |     337 B |
| GetByWords                 | 387.451 us | 19.2788 us | 27.6491 us |  1.9531 |    4425 B |
| GetByWordsToStringComplete | 517.446 us | 47.9095 us | 71.7086 us |  1.4648 |    3845 B |


## Usage
```csharp
public class AddressThModel
{
    public string SubDistrict { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
    public int PostalCode { get; set; }
}
```

```csharp
using AddressNet.Services.TH;

var result = AddressTH.GetAllAddress();

var result = AddressTH.GetByPostalCode(10100);

var result = AddressTH.GetByWords("กรุงเทพ");

string[] result = AddressTH.GetByWordsToStringComplete("บ้านไผ่");
```



<p align="left">
	<img src="https://github.githubassets.com/images/modules/site/sponsors/logo-mona.svg" height="100" width="100" alt="Mona logo"/>
</p>

[![](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub&color=%23fe8e86)](https://github.com/sponsors/zhamppx97)
