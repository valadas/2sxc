# Concept: Entity Relationships

## Purpose / Description

Data can be related to other data, like when a `Book` belongs to a `Category` and also has an `Author`. Since all data-items are called `Entities` we call this _Entity Relationships_. 

Additionally, there are also Entities which explicitly enhance/describes another _thing_, but that thing can be anything. That kind of relationship is called _Metadata_.

## How it Works

Each _Entity_ has many fields, some containing text, numbers etc. but some can also point to another item. These kinds of fields are called _Entity Fields_. When configured correctly, an entity-field shows a dropdown of items. So in the case of a book, the `Author` field may show a dropdown of `Person` items.

There are different types of relationships: 

* **1:n** means that one thing can refer to many other things - like a book which points to many categories
* **n:1** means that many things can refer to one thing - like many books pointing to the same author
* **n:n** means that many things can refer to many things - like many blog-posts pointing to many tags (the blog can refer to many tags, and each tag may be pointed to by many blogs)
* **1:1** relationships are when one thing refers to one other thing, and neither are re-used again. This is not often used in CMSs.

## Metadata Relationships

This is a very different concept, where an Entity enriches something else. Read more about it in [metadata](concept-metadata).

## Advanced Topics

* [Razor LINQ tutorial showing how to navigate between relationships](https://2sxc.org/dnn-tutorials/en/razor/linq/home)
* [RelationshipFilter Data Source to find items related to another item](DotNet-DataSource-RelationshipFilter)

## How to Use

todo: recipes to create, change etc.

## Future Features & Wishes

1. _none as of now_

## Read also
[//]: # "Additional links - often within this documentation, but can also go elsewhere"

* _none_

## History

1. Introduced in 2sxc 2.0