import React, { useState, useEffect } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import Api from '../../Api/Api'
import './jogo.css'

export default function Index() {
	const [jogos, setJogos] = useState([
	 	/* {
			id: 1,
			nome: 'indice 1',
			genero: 'Esporte',
			preco: 200,
			imagem: 'https://i.imgur.com/qbE20oC.jpg',
		},
		{
			id: 2,
			nome: 'indice 2',
			genero: 'Esporte',
			preco: 200,
			imagem: 'https://i.imgur.com/qbE20oC.jpg',
		},
		{
			id: 3,
			nome: 'indice 3',
			genero: 'Esporte',
			preco: 200,
			imagem: 'https://i.imgur.com/qbE20oC.jpg',
		},
		{
			id: 4,
			nome: 'indice 4',
			genero: 'Esporte',
			preco: 200,
			imagem: 'https://i.imgur.com/qbE20oC.jpg',
		},  */
	])
	const [redirect, setRedirect] = useState(false)

	useEffect(() => {
		Api.get('/Jogos')
			.then((response) => {
				setJogos(response.data)
				setRedirect(false)
			})
			.catch((error) => {
				console.log(error)
			})
	}, [redirect])

	function deleteJogo(id) {
		Api.delete(`/Jogos/${id}`)
		setRedirect(true)
	}

	return (
		<>
			<div className="container p-3">
				<Link to="/Jogos-Create" className="btn btn-sakura mb-2">
					Postar Jogo
				</Link>
				<div className="container d-flex justify-content-center">
					{jogos.map((jogo) => (
						<div
							className="p-2"
							key={jogo.id}
						>
							<div className="box">
								<img src={jogo.img} />
								<div className="box-content">
									<h3 className="title">{jogo.nome}</h3>
									<span className="post">{jogo.gamegen}</span>
								</div>
								<ul className="icon">
									<li>
										<Link
											to={`/Jogos-Update/${jogo.id}`}
											className="btn btn-info btn_x"
										><svg xmlns="http://www.w3.org/2000/svg" width="16" height="18" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
										<path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
										<path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
									</svg></Link>
									</li>
									<button
										className="btn btn-danger btn_x"
										onClick={() => deleteJogo(jogo.id)}
									>
										<svg
											xmlns="http://www.w3.org/2000/svg"
											width="16"
											height="16"
											fill="currentColor"
											className="bi bi-trash"
											viewBox="0 0 16 16"
										>
											<path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
											<path
												fill-rule="evenodd"
												d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"
											/>
										</svg>
									</button>
								</ul>
							</div>
						</div>
					))}
				</div>
			</div>
		</>
	)
}

{
	/*      {jogos.map((jogo) => (
                <tr className="text-white tr-hover" key={jogo.id}>
                  <td className="text-white">{jogo.id}</td>
                  <td className="text-white">{jogo.nome}</td>
                  <td className="text-white">{jogo.valor}</td>
                  <td className="d-flex justify-content-end">
                    <Link
                      to={`/Jogos-Update/${jogo.id}`}
                      className="btn btn-info"
                    >
                      Editar
                    </Link>
                    <button
                      className="btn btn-danger"
                      onClick={() => deleteJogo(jogo.id)}
                      style={{ marginLeft: "10px" }}
                    >
                      Deletar
                    </button>
                  
                
              ))} */
}
