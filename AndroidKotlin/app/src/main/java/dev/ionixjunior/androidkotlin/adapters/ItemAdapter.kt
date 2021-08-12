package dev.ionixjunior.androidkotlin.adapters

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.appcompat.view.menu.MenuView
import androidx.recyclerview.widget.RecyclerView
import com.google.android.gms.ads.nativead.NativeAd
import dev.ionixjunior.androidkotlin.R
import dev.ionixjunior.androidkotlin.models.Item
import dev.ionixjunior.androidkotlin.viewholders.BaseViewHolder
import dev.ionixjunior.androidkotlin.viewholders.ItemViewHolder

class ItemAdapter(private val itens: List<Item>) : RecyclerView.Adapter<BaseViewHolder>() {
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ItemViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.layout_item, parent, false)
        return ItemViewHolder(view)
    }

    override fun getItemCount(): Int {
        return itens.size
    }

    override fun onBindViewHolder(holder: BaseViewHolder, position: Int) {
        val item = itens[position]

        when (holder) {
            is ItemViewHolder -> {
                holder.bind(item)
            }
        }
    }

    fun setAd(ad: NativeAd) {

    }
}