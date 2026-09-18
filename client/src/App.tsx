import { APITester } from "./APITester";
import "./index.css";

import logo from "./logo.svg";
import reactLogo from "./react.svg";
import {Api, Book} from "../Api.ts";
import {useEffect, useState} from "react";

const MyApi = new Api();

export function App() {
    
    const [books, setBooks] = useState<Book[]>([]);
    
    useEffect(() => {
        MyApi.getBooks.libraryGetBooks().then(r => {
            const data = r.data;
            setBooks(data);
        })
    }, []);
    
  return (
    <div className="app">
        {
            books.map(b =>{
                return <div key={b.bookId}>{b.bookTitle}</div>
            })
        }
    </div>
  );
}

export default App;
