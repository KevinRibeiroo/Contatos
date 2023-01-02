import { BrowserRouter, Routes, Route} from "react-router-dom";
import Home from "./ContatosSite/Pages/Home/index.js";


export default function Routerjs(){
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" exact={true} element={<Home />}/>
            </Routes>
        </BrowserRouter>
    )
}
