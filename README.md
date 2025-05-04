CustomLinkedList<T>
This project provides a from-scratch implementation of a singly-linked list in C#. It exposes a straightforward ILinkedList<T> interface—extending ICollection<T>—with the following capabilities:

1. AddToFront(T item)
Insert an element at the head of the list in O(1) time.

2. AddToEnd(T item)
Append an element at the tail of the list in O(1) time.

3. ICollection<T> members
Full support for Add, Remove, Contains, CopyTo, Clear, Count, IsReadOnly, and enumeration via foreach.

4. Generic and null-friendly
Works with any type T, including nullable reference types; equality is handled by EqualityComparer<T>.Default.

5. Iterator-based enumeration
Uses yield return for efficient, on-demand traversal without pre-allocating intermediate collections.

Warning: This code has not been tested end-to-end. Use it as a learning reference or starting point for further development and add comprehensive unit tests before production use.

Acknowledgement
This project was completed as part of the Udemy course Complete C# Masterclass by Krystyna Ślusarczyk (https://www.udemy.com/course/ultimate-csharp-masterclass/). Having significant prior experience with C#, my goal was to refresh my skills and familiarize myself with the latest updates, features, and best practices introduced in recent versions.
