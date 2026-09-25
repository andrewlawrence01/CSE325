using Cse325DotnetWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cse325DotnetWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzasController : ControllerBase
{
    private static readonly List<Pizza> pizzas = new()
    {
        new Pizza
        {
            Id = 1,
            Name = "Margherita",
            IsGlutenFree = false
        },

        new Pizza
        {
            Id = 2,
            Name = "Hawaiian",
            IsGlutenFree = false
        },

        // Additional pizza required by the assignment.
        new Pizza
        {
            Id = 3,
            Name = "Pepperoni",
            IsGlutenFree = false
        }
    };


    // GET: /Pizzas
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return Ok(pizzas);
    }


    // GET: /Pizzas/1
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        Pizza? pizza = pizzas.Find(
            pizza => pizza.Id == id);

        if (pizza is null)
        {
            return NotFound();
        }

        return Ok(pizza);
    }


    // POST: /Pizzas
    [HttpPost]
    public ActionResult<Pizza> Create(Pizza pizza)
    {
        int nextId = pizzas.Count == 0
            ? 1
            : pizzas.Max(p => p.Id) + 1;

        pizza.Id = nextId;

        pizzas.Add(pizza);

        return CreatedAtAction(
            nameof(Get),
            new { id = pizza.Id },
            pizza);
    }


    // PUT: /Pizzas/1
    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        Pizza updatedPizza)
    {
        Pizza? existingPizza = pizzas.Find(
            pizza => pizza.Id == id);

        if (existingPizza is null)
        {
            return NotFound();
        }

        existingPizza.Name = updatedPizza.Name;
        existingPizza.IsGlutenFree =
            updatedPizza.IsGlutenFree;

        return NoContent();
    }


    // DELETE: /Pizzas/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Pizza? pizza = pizzas.Find(
            pizza => pizza.Id == id);

        if (pizza is null)
        {
            return NotFound();
        }

        pizzas.Remove(pizza);

        return NoContent();
    }
}