<img src="img/icon.png" alt="Icon" width="120" />

---
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
```

```csharp
var result = AddressTH.GetAllAddress().ToList();

var result = AddressTH.GetByPostalCode(10100).ToList();

var result = AddressTH.GetByWords("กรุงเทพ").ToList();
```

|SubDistrict  |District   |Province      |PostalCode   |
|------------ |---------- |------------- |------------ |
|คลองต้นไทร   |คลองสาน    |กรุงเทพมหานคร  |10600        |
|คลองสาน     |คลองสาน    |กรุงเทพมหานคร  |10600        |
|บางลำภูล่าง    |คลองสาน    |กรุงเทพมหานคร  |10600       |


```csharp
string[] result = AddressTH.GetByWordsToStringComplete("บ้านไผ่");
```

``` ini

{
    "ตำบล บ้านลาน, อำเภอ บ้านไผ่, จังหวัด ขอนแก่น, รหัสไปรษณีย์ 40110",
    "ตำบล บ้านไผ่, อำเภอ บ้านไผ่, จังหวัด ขอนแก่น, รหัสไปรษณีย์ 40110",
    "ตำบล ป่าปอ, อำเภอ บ้านไผ่, จังหวัด ขอนแก่น, รหัสไปรษณีย์ 40110"
}

```
