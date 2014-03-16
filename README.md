Easy MVVM Sample for Windows Phone 8
==================

This is a test sample of the use of MVVM design pattern on Windows Phone 8, showing the basics of use.

The sample shows the following:
- typical folder structure.
- command set up.
- use of DelegateCommand, including the case where a Func<object, bool> is provided that defines whether command can execute.
- two-way binding of TextBox's Text property such that it is updated with every keystroke rather than only updating after lost focus.
- setting up a ViewModel as a DataContext for a page
- connecting ViewModel to View through bindings
- unit testing

This project contains almost everything that I wish I knew when I started developing for Windows Phone. Hopefully it can help at least one person understand one way of using MVVM on Windows Phone. A <a href="http://yevgeller.blogspot.com/2014/02/another-simple-mvvm-tutorial-for.html">link</a> to my blog where I explain some of this code.
