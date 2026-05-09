# 📐 FigureLibrary

A C# class library for calculating geometric figure areas, built as a technical assessment for a **MindBox C# Developer (Junior/Middle)** position. The solution covers two tasks: a geometry library with unit tests, and an SQL query for a many-to-many product-category relationship.

---

## Task 1 — Geometry Library

### Requirements

- Calculate the area of a **Circle** by radius
- Calculate the area of a **Triangle** by three sides
- Unit tests
- Easy addition of new figures
- Area calculation **without knowing the figure type at compile-time** (polymorphism via interface)
- Check whether a triangle is a **right triangle**

### Solution

#### Interface design

```csharp
// Any figure — just one contract
IFigure figure = new Circle(5);
double area = figure.GetArea(); // works without knowing the type

// Triangle extends IFigure with right-angle check
ITriangle triangle = new Triangle(3, 4, 5);
bool isRight = triangle.IsRectangle(); // true
```

#### `Circle`
- Validates that `radius > 0`, throws `ArgumentException` otherwise
- Area: `π × r²`
- `virtual` — can be extended by subclasses

#### `Triangle`
- Validates all sides are `> 0` and satisfy the triangle inequality (`a + b > c`)
- Sorts sides internally to simplify the right-angle check — no need for three conditional checks
- Area: **Heron's formula** — `√(s(s−a)(s−b)(s−c))`
- Right-angle check: Pythagorean theorem with floating-point epsilon (`0.00001`) to handle double precision errors
- `sealed` — not intended for inheritance

### Architecture

```
FigureLibruary/
├── Interface/
│   ├── IFigure.cs       # GetArea() — common contract for all figures
│   └── ITriangle.cs     # IsRectangle() — extends IFigure for triangles
└── Figure/
    ├── Circle.cs        # Implements IFigure
    └── Triangle.cs      # Implements ITriangle (sealed, Heron's formula)

TestFigureLibruary/
├── TestCircle.cs        # xUnit: correct area, constructor validation
└── TestTriangle.cs      # xUnit: correct area, right-angle detection, constructor validation
```

### Unit Tests (xUnit)

| Test | Cases covered |
|---|---|
| `Circle.GetArea` | Area of unit circle = π |
| `Circle` constructor | Throws on `radius = 0`, `radius < 0` |
| `Triangle.GetArea` | Scalene triangle, classic 3-4-5 right triangle |
| `Triangle` constructor | Throws on zero/negative sides, degenerate triangles (a+b≤c) |
| `Triangle.IsRectangle` | `false` for non-right triangles, `true` for Pythagorean triples and float edge cases |

### Run Tests

```bash
git clone https://github.com/NackBard/FigureLibruary.git
cd FigureLibruary
dotnet test
```

### Adding a New Figure

Implement `IFigure` (or `ITriangle` for polygons with extra checks) — no existing code needs to change:

```csharp
public class Rectangle : IFigure
{
    private double width, height;
    public Rectangle(double width, double height) { ... }
    public double GetArea() => width * height;
}
```

---

## Task 2 — SQL Query

**Schema:** Products and Categories in a many-to-many relationship via a `ProductCategory` join table.

**Task:** Select all `Product Name – Category Name` pairs. Products with no category must still appear.

```sql
SELECT Product.Name, Category.Name
FROM Product
LEFT JOIN ProductCategory ON Product_Id = Product.Id
LEFT JOIN Category ON Category_Id = Category.Id
ORDER BY Product.Name
```

`LEFT JOIN` ensures products without any assigned category are included in the result with `NULL` in the Category column.

**Schema definition** and test data inserts are in [`SQL/Task2.sql`](SQL/Task2.sql).

---

## 🛠️ Tech Stack

| | Technology |
|---|---|
| Language | C# |
| Framework | .NET 6 |
| Testing | xUnit 2.9, coverlet |
| Database | MS SQL Server |

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

> Built with ❤️ using C# .NET 6 and xUnit
