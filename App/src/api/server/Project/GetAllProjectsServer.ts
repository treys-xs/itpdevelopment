import axios from 'axios'
import {serverApi} from "../../../constants/serverApi";
import {IProject} from "../../../models/IProject";

export async function GetAllProjectsServer(){
    return await axios.get<IProject[]>(`${serverApi}/project/getall`)
}